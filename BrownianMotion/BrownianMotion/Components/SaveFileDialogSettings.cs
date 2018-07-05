using System;
using System.Windows.Forms;

namespace cslib.FormElement.Dialog
{
    public class SaveFileDialogSettings : IDisposable
    {
        protected SaveFileDialog _dialog;
        public SaveFileDialog Dialog { get { return _dialog; } }

        public SaveFileDialogSettings(SaveFileDialog handle)
        {
            if (handle != null)
                _dialog = handle;
            else
                _dialog = new SaveFileDialog();
        }

        ~SaveFileDialogSettings()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_dialog != null)
                {
                    _dialog.Dispose();
                    _dialog = null;
                }
            }

            // free native resources if there are any.
            //if (nativeResource != IntPtr.Zero)
            //{
            //    Marshal.FreeHGlobal(nativeResource);
            //    nativeResource = IntPtr.Zero;
            //}
        }
        public virtual void ApplySettings()
        {
            _dialog.AddExtension = true;
            _dialog.AutoUpgradeEnabled = true;
            _dialog.CheckFileExists = false;
            _dialog.CheckPathExists = true;
            _dialog.DefaultExt = "txt";
            _dialog.DereferenceLinks = true;
            _dialog.FileName = "";
            _dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            _dialog.InitialDirectory = @"C:\";
            _dialog.RestoreDirectory = true;
            _dialog.ShowHelp = false;
            _dialog.SupportMultiDottedExtensions = true;
            _dialog.Title = "Save File";
            _dialog.ValidateNames = true;
        }
    }
}
