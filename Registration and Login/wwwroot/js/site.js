//const togglePassword = document.querySelector('#togglePassword');
//const password = document.querySelector('#id_password');

//togglePassword.addEventListener('click', function (e) {

//    if (password.getAttribute('type') === 'password') {
//        password.setAttribute('type', 'text');
//        this.src = "/icons/eye-show.png"
//    }
//    else {
//        password.setAttribute('type', 'password');
//        this.src = "/icons/eye-hide.png"
//    }
//});

function myFunction(pass_id, toggle_id) {
    const togglePassword = document.querySelector(toggle_id);
    const password = document.querySelector(pass_id);

    togglePassword.addEventListener('click', function (e) {

        if (password.getAttribute('type') === 'password') {
            password.setAttribute('type', 'text');
            this.src = "/icons/eye-show.png"
        }
        else {
            password.setAttribute('type', 'password');
            this.src = "/icons/eye-hide.png"
        }
    });
}

myFunction('#id_password' ,'#togglePassword')
myFunction('#id_confirm_password', '#toggleConfirmPassword')