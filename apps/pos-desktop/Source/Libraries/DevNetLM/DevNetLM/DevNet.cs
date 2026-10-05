using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using NextGenOS.Licensing.Windows;
using DevNetLM.Models;
using NextGenOS.Licensing;

namespace DevNetLM
{
    /// <summary>
    /// The POS asks two things of this class: Validate() at start-up and when the main menu opens, and ShowActivation() when
    /// Validate() says the program may not run. The answers now come from the signed licence (spec: licensing/spec/LICENCE-FORMAT.md).
    /// </summary>
    public static class DevNet
    {
        private static LicenceHeartbeat _heartbeat;
        private static int _closing;

        /// <summary>Looks at the licence. LicenseData is null (and ShowActivation says whether to open the window) when the program may not run.</summary>
        public static LicenseResponse Validate()
        {
            var manager = PosLicence.Manager;
            var state = manager.Evaluate();
            var view = LegacyAdapter.From(state, DateTime.UtcNow);
            if (view.Allowed)
            {
                StartHeartbeat(manager);
                // When it is time, check in quietly in the background: the program never waits for the network.
                Task.Run(async () => { try { await manager.CheckInAsync().ConfigureAwait(false); } catch (Exception) { } });
            }
            return new LicenseResponse
            {
                LicenseData = view.Allowed ? ToLegacy(view) : null,
                Message = view.Message,
                ShowActivation = view.ShowActivation,
            };
        }

        /// <summary>Opens the activation window. When it succeeds the program restarts itself, so that it starts with a licence.</summary>
        public static bool ShowActivation()
        {
            using (var window = new ActivationForm(PosLicence.Manager))
            {
                window.ShowDialog();
                if (window.WasActivated)
                {
                    MessageBox.Show("Thank you. Smart Retail POS is activated and will start again now.", "Activated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    return true;
                }
            }
            return false;
        }

        private static LicenseData ToLegacy(LegacyView v)
        {
            return new LicenseData
            {
                ProName = v.ProductName,
                LKey = v.LicenceId,
                SYSID = v.SystemId,
                VFrom = v.From,
                VTill = v.Till,
                TStamp = DateTime.Now,
                CusName = v.CustomerName,
                CusEmail = v.CustomerEmail,
                CusPhone = v.CustomerPhone,
                ProductId = "smart-retail-pos",
                issuedby = "NextGenOS",
                issued_byid = "NextGenOS",
            };
        }

        /// <summary>Re-checks the licence while the program runs, so a withdrawn or ended licence stops a running shop too.</summary>
        private static void StartHeartbeat(LicenceManager manager)
        {
            if (_heartbeat != null) return;
            _heartbeat = new LicenceHeartbeat(manager, state =>
            {
                if (System.Threading.Interlocked.Exchange(ref _closing, 1) == 1) return;
                try { MessageBox.Show(state.Message + "\n\nThe program will close now. Please save your work first next time.", "Smart Retail POS licence", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                catch (Exception) { }
                Environment.Exit(0);
            });
            _heartbeat.Start();
        }
    }
}
