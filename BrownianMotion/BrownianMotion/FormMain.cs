using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace BrownianMotion
{
    using Components;
    using cslib.FormElement.Dialog;

    public partial class FormMain : Form
    {
        private SaveFileDialogSettings _saveFileDialogSetting;
        private RandomData _generator;
        private Entity _model;

        public FormMain()
        {
            InitializeComponent();

            btnSaveAs.Visible = false;
            progressBarIter.Visible = false;

            _saveFileDialogSetting = new SaveFileDialogSettings(saveFileDialog1);
            _saveFileDialogSetting.ApplySettings();

            _generator = new RandomData();
            _generator.SampleGeneratedEvent += _generator_SampleGeneratedEvent;

            _model = new Entity();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            AsyncGenerate();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtFileWriter writer = new TxtFileWriter(saveFileDialog1.FileName);

                if(_generator.Samples != null)
                {
                    if(_generator.Samples.Count > 0)
                        writer.Write(_generator.Samples);
                }
            }
        }

        private delegate void AsyncTaskDelegate();
        private void AsyncGenerate()
        {
            AsyncTaskDelegate asyncTask = new AsyncTaskDelegate(Generate);
            IAsyncResult ar = asyncTask.BeginInvoke(new AsyncCallback(AsyncTaskCallback), null);
        }
        private void AsyncTaskCallback(IAsyncResult ar)
        {
            AsyncTaskDelegate asyncTask = (AsyncTaskDelegate)((AsyncResult)ar).AsyncDelegate;
            asyncTask.EndInvoke(ar);
        }

        private void Generate()
        {
            try
            {
                //0. Hide "Save As" button
                ButtonSaveAs_visible(false);

                //1. Gather inputs
                ParseInput(_model);

                //2. Make Progress Bar visible
                ProgressBar_visible(true);

                //3. Generate data sample, update progress bar per sample generated
                _generator.Generate(_model);

                //4. pause
                System.Threading.Thread.Sleep(1000);

                //5. Make Progress Bar invisible
                ProgressBar_visible(false);

                //6. Show "Save As" button
                ButtonSaveAs_visible(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ParseInput(Entity model)
        {
            if(model == null)
            {
                model = new Entity();
            }

            model.count = int.Parse(tbSampleCount.Text);
            model.min = int.Parse(tbMin.Text);
            model.max = int.Parse(tbMax.Text);
            model.offset = int.Parse(tbOffset.Text);
        }

        private void ProgressBar_visible(bool is_visible)
        {
            progressBarIter.Invoke((MethodInvoker)(() =>
            {
                progressBarIter.Visible = is_visible;
            }));
        }

        private void ButtonSaveAs_visible(bool is_visible)
        {
            btnSaveAs.Invoke((MethodInvoker)(() =>
            {
                btnSaveAs.Visible = is_visible;
            }));
        }

        private void _generator_SampleGeneratedEvent(object sender, EventArgs e)
        {
            int i = (int)sender;
            progressBarIter.Invoke((MethodInvoker)(() =>
            {
                if(_model != null)
                    progressBarIter.Value = (int)((i + 1) * 100 / _model.count);
            }));
        }
    }
}
