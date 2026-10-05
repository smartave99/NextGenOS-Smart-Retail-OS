namespace SmartRetail.AI.Settings
{
    /// <summary>
    /// Camera search: a photo finds a product by its barcode (always, on this PC) and, once the owner turns it on, by its
    /// look (a DINOv2 model, downloaded once, run on this PC). The dashboard owns these settings.
    /// </summary>
    public sealed class CameraSearchSettings
    {
        /// <summary>Find products by their look, not only their barcode: needs the model, from about 88 MB.</summary>
        public bool FindByLook { get; set; }

        /// <summary>
        /// The id of the model that finds products by their look (the app's list of models); empty for the first one, DINOv2-small,
        /// which every shop starts with. It changes only when the owner chooses another model: an update of the app never does,
        /// since a switch downloads the model and learns every product's photos again.
        /// </summary>
        public string Model { get; set; } = "";
    }
}
