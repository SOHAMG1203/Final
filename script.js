document.addEventListener('DOMContentLoaded', function () {
    var profileIcon = document.getElementById('profileIcon');
    var loginRegisterBox = document.getElementById('loginRegisterBox');

    // Check if the loginFailed variable is defined and true
    if (typeof loginFailed !== 'undefined' && loginFailed) {
        loginRegisterBox.style.display = 'block';
    } else {
        loginRegisterBox.style.display = 'none';
    }

    profileIcon.addEventListener('click', function () {
        if (loginRegisterBox.style.display === 'none') {
            loginRegisterBox.style.display = 'block';
        } else {
            loginRegisterBox.style.display = 'none';
        }
    });
});
