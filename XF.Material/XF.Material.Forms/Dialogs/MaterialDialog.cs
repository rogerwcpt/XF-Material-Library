﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XF.Material.Forms.Dialogs.Configurations;

namespace XF.Material.Forms.Dialogs
{
    /// <summary>
    /// Class for showing dialogs and snackbar.
    /// </summary>
    public class MaterialDialog : IMaterialDialog
    {
        /// <summary>
        /// The current instance to use for showing modal dialogs.
        /// </summary>
        public static IMaterialDialog Instance { get; internal set; }

        internal MaterialDialog() { }

        /// <summary>
        /// Sets the global styles for <see cref="MaterialAlertDialog"/>, <see cref="MaterialLoadingDialog"/>,and <see cref="MaterialSnackbar"/>. Parameters can be null.
        /// </summary>
        /// <param name="dialogConfiguration">Global style for <see cref="MaterialAlertDialog"/>.</param>
        /// <param name="loadingDialogConfiguration">Global style for <see cref="MaterialLoadingDialog"/>.</param>
        /// <param name="snackbarConfiguration">Global style for <see cref="MaterialSnackbar"/>.</param>
        public void SetGlobalStyles(MaterialAlertDialogConfiguration dialogConfiguration, MaterialLoadingDialogConfiguration loadingDialogConfiguration, MaterialSnackbarConfiguration snackbarConfiguration, MaterialSimpleDialogConfiguration simpleDialogConfiguration)
        {
            MaterialAlertDialog.GlobalConfiguration = dialogConfiguration;
            MaterialLoadingDialog.GlobalConfiguration = loadingDialogConfiguration;
            MaterialSnackbar.GlobalConfiguration = snackbarConfiguration;
            MaterialSimpleDialog.GlobalConfiguration = simpleDialogConfiguration;
        }

        /// <summary>
        /// Shows an alert dialog for acknowledgement. It only has a single, dismissive action used for acknowledgement.
        /// </summary>
        /// <param name="message">The message of the alert dialog.</param>
        /// <param name="configuration">The style of the alert dialog.</param>
        public async Task AlertAsync(string message, MaterialAlertDialogConfiguration configuration = null)
        {
            await MaterialAlertDialog.AlertAsync(message, configuration: configuration);
        }

        /// <summary>
        /// Shows an alert dialog for acknowledgement. It only has a single, dismissive action used for acknowledgement.
        /// </summary>
        /// <param name="message">The message of the alert dialog.</param>
        /// <param name="acknowledgementText">The text of the acknowledgement button.</param>
        /// <param name="configuration">The style of the alert dialog.</param>
        public async Task AlertAsync(string message, string acknowledgementText, MaterialAlertDialogConfiguration configuration = null)
        {
            await MaterialAlertDialog.AlertAsync(message, acknowledgementText, configuration);
        }

        /// <summary>
        /// Shows an alert dialog for acknowledgement. It only has a single, dismissive action used for acknowledgement.
        /// </summary>
        /// <param name="message">The message of the alert dialog.</param>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="acknowledgementText">The text of the acknowledgement button.</param>
        /// <param name="configuration">The style of the alert dialog.</param>
        public async Task AlertAsync(string message, string title, string acknowledgementText, MaterialAlertDialogConfiguration configuration = null)
        {
            await MaterialAlertDialog.AlertAsync(message, title, acknowledgementText, configuration);
        }

        /// <summary>
        /// Shows an alert dialog for confirmation. Returns true when the confirm button was clicked, false if the dismiss button was clicked or if the alert dialog was dismissed.
        /// </summary>
        /// <param name="message">The message of the alert dialog.</param>
        /// <param name="confirmingText">The text of the confirmation button.</param>
        /// <param name="dismissiveText">The text of the dismissive button</param>
        /// <param name="configuration">The style of the alert dialog.</param>
        public async Task<bool> ConfirmAsync(string message, string confirmingText = "Ok", string dismissiveText = "Cancel", MaterialAlertDialogConfiguration configuration = null)
        {
            return await MaterialAlertDialog.ConfirmAsync(message, confirmingText, dismissiveText, configuration);
        }

        /// <summary>
        /// Shows an alert dialog for confirmation. Returns true when the confirm button was clicked, false if the dismiss button was clicked or if the alert dialog was dismissed.
        /// </summary>
        /// <param name="message">The message of the alert dialog.</param>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="confirmingText">The text of the confirmation button.</param>
        /// <param name="dismissiveText">The text of the dismissive button</param>
        /// <param name="configuration">The style of the alert dialog.</param>
        public async Task<bool> ConfirmAsync(string message, string title, string confirmingText = "Ok", string dismissiveText = "Cancel", MaterialAlertDialogConfiguration configuration = null)
        {
            return await MaterialAlertDialog.ConfirmAsync(message, title, confirmingText, dismissiveText, configuration);
        }

        /// <summary>
        /// Shows a dialog indicating a running task.
        /// </summary>
        /// <param name="message">The message of the dialog.</param>
        /// <param name="configuration">The style of the loading dialog.</param>
        public async Task<IMaterialModalPage> LoadingDialogAsync(string message, MaterialLoadingDialogConfiguration configuration = null)
        {
            return await MaterialLoadingDialog.Loading(message, configuration);
        }

        /// <summary>
        /// Shows a snackbar indicating a running task.
        /// </summary>
        /// <param name="message">The message of the snackbar.</param>
        /// <param name="configuration">The style of the snackbar.</param>
        public async Task<IMaterialModalPage> LoadingSnackbarAsync(string message, MaterialSnackbarConfiguration configuration = null)
        {
            return await MaterialSnackbar.Loading(message, configuration);
        }

        /// <summary>
        /// Shows a snackbar with no action.
        /// </summary>
        /// <param name="message">The message of the snackbar.</param>
        /// <param name="msDuration">The duration, in milliseconds, before the snackbar is automatically dismissed.</param>
        /// <param name="configuration">The style of the snackbar.</param>
        public async Task SnackbarAsync(string message, int msDuration = MaterialSnackbar.DURATION_LONG, MaterialSnackbarConfiguration configuration = null)
        {
            await MaterialSnackbar.ShowAsync(message, msDuration, configuration);
        }

        /// <summary>
        /// Shows a snackbar with an action. Returns true if the snackbar's action button was clicked, or false if the snackbar was automatically dismissed.
        /// </summary>
        /// <param name="message">The message of the snackbar.</param>
        /// <param name="actionButtonText">The label text of the snackbar's button.</param>
        /// <param name="msDuration">The duration, in milliseconds, before the snackbar is automatically dismissed.</param>
        /// <param name="configuration">The style of the snackbar.</param>
        public async Task<bool> SnackbarAsync(string message, string actionButtonText, int msDuration = MaterialSnackbar.DURATION_LONG, MaterialSnackbarConfiguration configuration = null)
        {
            return await MaterialSnackbar.ShowAsync(message, actionButtonText, msDuration, configuration);
        }

        /// <summary>
        /// Shows a simple dialog that allows the user to select one of listed actions. Returns the index of the selected action.
        /// </summary>
        /// <param name="actions">The list of actions.</param>
        public async Task<int> SelectActionAsync(List<string> actions, MaterialSimpleDialogConfiguration configuration = null)
        {
            return await MaterialSimpleDialog.ShowAsync(null, actions, configuration);
        }

        /// <summary>
        /// Shows a simple dialog that allows the user to select one of listed actions. Returns the index of the selected action.
        /// </summary>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="actions">The list of actions.</param>
        public async Task<int> SelectActionAsync(string title, List<string> actions, MaterialSimpleDialogConfiguration configuration = null)
        {
            return await MaterialSimpleDialog.ShowAsync(title, actions, configuration);
        }
    }
}
