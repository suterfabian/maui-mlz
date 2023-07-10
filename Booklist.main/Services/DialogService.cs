namespace Booklist.main.Services
{
    public class DialogService
    {
        /// <summary>
        /// Confirm-Box
        /// </summary>
        /// <param name="message">Message inside the Confirm-Box</param>
        /// <param name="title">Title of Confirm-Box</param>
        /// <returns>bool</returns>
        public static Task<bool> ConfirmAsync(string message, string title = "Bestätigung")
        {
            return DialogService.GetMainPage().DisplayAlert(title, message, "Ja", "Nein");
        }

        /// <summary>
        /// Alert-Box
        /// </summary>
        /// <param name="message">Message inside the Alert-box</param>
        /// <param name="title">Title of the Alert-Box</param>
        public static Task AlertAsync(string message, string title = "Hinweis")
        {
            return DialogService.GetMainPage().DisplayAlert(title, message, "OK");
        }

        private static Page GetMainPage()
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                return Application.Current.MainPage;
            }

            throw new InvalidOperationException("DialogService.GetMainPage() darf nicht null sein!");
        }
    }
}