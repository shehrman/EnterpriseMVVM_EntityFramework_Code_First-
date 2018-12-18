namespace UnitTest1
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using EnterpriseMVVM.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
   public  class ViewModelTests
    {

      
            [TestMethod]
            public void IsAbstractBaseClass()
            {
                Type t = typeof(ViewModel);

                Assert.IsTrue(t.IsAbstract);
            }

        [TestMethod]
        public void IsIDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }

        [TestMethod]
        public void IsObservableObject()
        {
            Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSupported()
        {
            var viewModel = new StubViewModel();
            string value = viewModel.Error;
        }

        [TestMethod]
        public void IndexerValidatesPropertyNameWithInvalidValue()
        {
            var viewModel = new StubViewModel();
            Assert.IsNotNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerValidatesPropertyNameWithValidValue()
        {
            var viewModel = new StubViewModel
            {
                RequiredProperty = "Some Value"
            };

            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        private class StubViewModel : ViewModel
        {
            [Required]
            public string RequiredProperty { get; set; }
        }
    }

    }

