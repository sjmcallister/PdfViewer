using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PdfViewer
{
    internal class DefaultSettings
    {
        public int DpiX { get; private set; }
        public int DpiY { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="landscape"></param>
		public DefaultSettings(bool landscape)
		{
			using (var dialog = new PrintDialog())
			{
				bool found = false;

				try
				{
					if (landscape)
					{
						foreach (PrinterResolution resolution in dialog.PrinterSettings.PrinterResolutions)
						{
							if (resolution.Kind == PrinterResolutionKind.Custom)
							{
								DpiX = resolution.X;
								DpiY = resolution.Y;
								Width = (int)((dialog.PrinterSettings.DefaultPageSettings.PaperSize.Height / 100.0) * resolution.X);
								Height = (int)((dialog.PrinterSettings.DefaultPageSettings.PaperSize.Width / 100.0) * resolution.Y);

								found = true;
								break;
							}
						}
					}
					else
					{
						foreach (PrinterResolution resolution in dialog.PrinterSettings.PrinterResolutions)
						{
							if (resolution.Kind == PrinterResolutionKind.Custom)
							{
								DpiX = resolution.X;
								DpiY = resolution.Y;
								Width = (int)((dialog.PrinterSettings.DefaultPageSettings.PaperSize.Width / 100.0) * resolution.X);
								Height = (int)((dialog.PrinterSettings.DefaultPageSettings.PaperSize.Height / 100.0) * resolution.Y);

								found = true;
								break;
							}
						}
					}
				}
				catch
				{
					// Ignore any exceptions; just use defaults.
				}

				if (!found)
				{
					// Default to A4 size.

					DpiX = 600;
					DpiY = 600;
					Width = (int)(8.5 * DpiX);
					Height = (int)(11 * DpiY);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
        public DefaultSettings()
        {
            using (var dialog = new PrintDialog())
            {
                bool found = false;

                try
                {
                    foreach (PrinterResolution resolution in dialog.PrinterSettings.PrinterResolutions)
                    {
                        if (resolution.Kind == PrinterResolutionKind.Custom)
                        {
                            DpiX = resolution.X;
                            DpiY = resolution.Y;
                            Width = (int)((dialog.PrinterSettings.DefaultPageSettings.PaperSize.Width / 100.0) * resolution.X);
                            Height = (int)((dialog.PrinterSettings.DefaultPageSettings.PaperSize.Height / 100.0) * resolution.Y);

                            found = true;
                            break;
                        }
                    }
                }
                catch
                {
                    // Ignore any exceptions; just use defaults.
                }

                if (!found)
                {
                    // Default to A4 size.

                    DpiX = 600;
                    DpiY = 600;
                    Width = (int)(8.5 * DpiX);
                    Height = (int)(11 * DpiY);
                }
            }
        }
    }
}
