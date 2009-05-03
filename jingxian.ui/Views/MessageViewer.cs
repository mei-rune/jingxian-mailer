using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace jingxian.ui.views
{
    using Empinia.Core.Runtime;
    using Empinia.Core.Runtime.Filters;
    using Empinia.UI;
    using Empinia.UI.Workbench;
    using Empinia.UI.Navigator;

    using jingxian.data;
    using jingxian.domainModel;

    public class MessageView :  IView
    {
        IViewPart m_viewPart;
        Control _control;

        public MessageView()
        {
        }        
        
        #region IView 成员

        public void Configure(IViewPart owningPart)
        {
            m_viewPart = owningPart;
        }

        public IViewPart OwningViewPart
        {
            get { return m_viewPart; }
        }

        public Control Widget
        {
            get 
            {
                if (null == _control)
                    _control = new ui.controls.MessageViewer();
                return _control; 
            }
        }

        #endregion
    }
}
