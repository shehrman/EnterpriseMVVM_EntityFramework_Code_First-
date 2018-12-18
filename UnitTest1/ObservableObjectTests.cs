
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest1
{
    using EnterpriseMVVM.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
 public class ObservableObjectTests
    {
        [TestMethod]
        public void PropertyChangeEventhandlerIsRaised()
        {
            var obj = new StubObservableObject();
            bool raised = false;
            obj.PropertyChanged += (sender, e) =>
             {
                 Assert.IsTrue(e.PropertyName == "ChangedProperty");
                 raised = true;
             };
            obj.ChangedProperty = "Some value";
            if (!raised) Assert.Fail("PropertyChanged was never invoked");
          
        }

        private class StubObservableObject: ObservableObject
        {
            private string  changedProperty;

            public string  ChangedProperty
            {
                get {
                    return changedProperty;
                }
                set {
                    changedProperty = value;
                    NotifyPropertyChanged();
                }
            }

        }
    }
}
