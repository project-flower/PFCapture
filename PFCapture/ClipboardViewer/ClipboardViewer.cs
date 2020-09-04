using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace PFCapture
{
    #region Public Classes

    public class ClipboardEventArgs : EventArgs
    {
    }

    public delegate void ClipboardEventHandler(object sender, ClipboardEventArgs e);

    public partial class ClipboardViewer : Component
    {
        #region Public Fields

        public event ClipboardEventHandler DrawClipBoard = delegate { };

        #endregion

        #region Private Fields

        private bool enabled;
        private ContainerControl owner;
        private Window window;

        #endregion

        #region Public Properties

        public bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                if (value == enabled)
                {
                    return;
                }

                enabled = value;

                if (DesignMode)
                {
                    return;
                }

                if (value)
                {
                    var form = owner as Form;

                    if (form == null)
                    {
                        return;
                    }

                    window.JoinClipboardChain(form);
                }
                else
                {
                    window.LeaveClipboardChain();
                }
            }
        }

        public override ISite Site
        {
            get
            {
                return base.Site;
            }

            set
            {
                base.Site = value;

                if (value == null)
                {
                    return;
                }

                var designerHost = value.GetService(typeof(IDesignerHost)) as IDesignerHost;

                if (designerHost == null)
                {
                    return;
                }

                IComponent rootComponent = designerHost.RootComponent;

                if (rootComponent is ContainerControl)
                {
                    owner = rootComponent as ContainerControl;
                }
            }
        }

        public ContainerControl Owner
        {
            get
            {
                return owner;
            }

            set
            {
                if (value == owner)
                {
                    return;
                }

                var form = value as Form;

                if (form == null)
                {
                    return;
                }

                owner = value;

                if (DesignMode)
                {
                    return;
                }

                // デザイナで Enabled を true にした時に、owner が null で動作しないため、
                // 再度設定する。
                window.LeaveClipboardChain();

                if (enabled)
                {
                    window.JoinClipboardChain(form);
                }
            }
        }

        #endregion

        #region Public Methods

        public ClipboardViewer()
        {
            enabled = false;
            window = new Window();
            window.DrawClipboard += window_DrawClipboard;
        }

        ~ClipboardViewer()
        {
            window.LeaveClipboardChain();
            window.DrawClipboard -= window_DrawClipboard;
        }

        #endregion

        #region Private Methods

        private void window_DrawClipboard(object sender, ClipboardEventArgs e)
        {
            DrawClipBoard(this, e);
        }

        #endregion
    }

    #endregion
}
