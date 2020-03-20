using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;

namespace BookKeeper.UI.Infrastructure
{
    public class FormFactory
    {
        private readonly ILifetimeScope _scope;

        public FormFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public TForm CreateForm<TForm>() where TForm : Form
        {
            var formScope = _scope.BeginLifetimeScope("FormScope");
            var form = formScope.Resolve<TForm>();
            form.Closed += (s, e) => formScope.Dispose();
            return form;
        }
    }
}
