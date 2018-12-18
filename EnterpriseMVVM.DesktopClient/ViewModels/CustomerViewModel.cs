namespace EnterpriseMVVM.DesktopClient.ViewModels
{
    using EnterpriseMVVM.Windows;
    using System.ComponentModel.DataAnnotations;
    using System.Windows;

    /// <summary>
    /// A View-Model that represents a customer and its state information.
    /// </summary>
    public class CustomerViewModel : ViewModel
    {
        private string customerName;

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                customerName = value;
                NotifyPropertyChanged();
            }
        }

        protected override string OnValidate(string propertyName)
        {
            if (CustomerName != null && !CustomerName.Contains(" "))
                return "Customer name must contain both a first and last name.";

            return base.OnValidate(propertyName);
        }
    }
}