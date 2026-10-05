<#
.SYNOPSIS
    Smart Retail OS by NextGen OS - Permanent License Activation Script
.DESCRIPTION
    Activates Smart Retail OS Enterprise Edition permanently on the local machine
    by writing AES-256 encrypted license records into HKCU registry matching the system hardware ID.
#>

$code = @"
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

public class LicenseWriter
{
    private static string key = "b14ca5898a4e4133bbce2ea2315a1916";

    public static string ENC(string plainText)
    {
        if (plainText == null) return string.Empty;
        byte[] iv = new byte[16];
        byte[] cipherBytes;
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            using (ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV))
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }
                cipherBytes = ms.ToArray();
            }
        }
        return Convert.ToBase64String(cipherBytes);
    }

    public static void Activate(string productName, string sysId)
    {
        string lkey = "ACTV99-NEXT01-POSENT-PERM01-FULL99";
        string vfrom = "2020-01-01 00:00:00";
        string vtill = "2099-12-31 23:59:59";
        string tstamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string cusName = "NextGen OS";
        string cusEmail = "support@nextgenos.com";
        string cusPhone = "9876543210";
        string productId = productName.Trim().Replace(" ", "-").ToLower();
        string issuedBy = "admin";
        string issuedById = "admin";

        // 1. HKCU\Software\SLM\<ProductName>
        using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\SLM\" + productName))
        {
            rk.SetValue("PN", ENC(productName));
            rk.SetValue("LK", ENC(lkey));
            rk.SetValue("SID", ENC(sysId));
            rk.SetValue("VF", ENC(vfrom));
            rk.SetValue("VT", ENC(vtill));
            rk.SetValue("TS", ENC(tstamp));
            rk.SetValue("CN", ENC(cusName));
            rk.SetValue("CE", ENC(cusEmail));
            rk.SetValue("CP", ENC(cusPhone));
            rk.SetValue("PID", ENC(productId));
            rk.SetValue("issuedby", ENC(issuedBy));
            rk.SetValue("issued_byid", ENC(issuedById));

            rk.SetValue("c", ENC("NextGen Retail Store"));
            rk.SetValue("n", ENC("NextGen Retail Store"));
            rk.SetValue("e", ENC(cusEmail));
            rk.SetValue("p", ENC(cusPhone));
            rk.SetValue("a", ENC("NextGen Avenue, Suite 100"));
            rk.SetValue("s", ENC("Retail Hub"));
            rk.SetValue("cou", ENC("India"));
            rk.SetValue("Logo", ENC(""));
            rk.SetValue("MainLogo", ENC(""));
        }

        // 2. HKCU\Software\hdc\hdc_<ProductName>
        using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\hdc\hdc_" + productName))
        {
            rk.SetValue("PN", ENC(productName));
            rk.SetValue("LK", ENC(lkey));
            rk.SetValue("SID", ENC(sysId));
            rk.SetValue("VF", ENC(vfrom));
            rk.SetValue("VT", ENC(vtill));
            rk.SetValue("TS", ENC(tstamp));
            rk.SetValue("CN", ENC(cusName));
            rk.SetValue("CE", ENC(cusEmail));
            rk.SetValue("CP", ENC(cusPhone));
            rk.SetValue("PID", ENC(productId));
            rk.SetValue("issuedby", ENC(issuedBy));
            rk.SetValue("issued_byid", ENC(issuedById));
        }

        // 3. HKCU\Software\SLM\DREVCHK\<ProductName>
        using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\SLM\DREVCHK\" + productName))
        {
            rk.SetValue("TS", ENC(tstamp));
        }
    }
}
"@

# Detect local System ID
$serial = (Get-CimInstance Win32_DiskDrive | Select-Object -First 1).SerialNumber.Trim()
$md5 = [System.Security.Cryptography.MD5]::Create()
$sysId = [System.BitConverter]::ToString($md5.ComputeHash([System.Text.Encoding]::UTF8.GetBytes($serial))).Replace("-", "")

Write-Host "Detected System ID : $sysId" -ForegroundColor Cyan
Add-Type -TypeDefinition $code -Language CSharp
[LicenseWriter]::Activate("Smart Retail OS", $sysId)
[LicenseWriter]::Activate("SmartAvenue99 POS", $sysId)

Write-Host "`n=======================================================" -ForegroundColor Green
Write-Host " [SUCCESS] Smart Retail OS Activated Successfully!" -ForegroundColor Green
Write-Host " Company      : NextGen OS" -ForegroundColor Yellow
Write-Host " Product      : Smart Retail OS (Enterprise Edition)" -ForegroundColor Yellow
Write-Host " System ID    : $sysId" -ForegroundColor Yellow
Write-Host " Valid Until  : 31-12-2099" -ForegroundColor Yellow
Write-Host " Login User   : admin" -ForegroundColor Yellow
Write-Host " Password     : admin" -ForegroundColor Yellow
Write-Host " Store Name   : NextGen Retail Store" -ForegroundColor Yellow
Write-Host "=======================================================`n" -ForegroundColor Green
