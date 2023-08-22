// LoginViewModeli post etmek için iþlev
function postLoginViewModel(email, password) {
    fetch('/Login/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    })
        .then(response => response.json())
        .then(data => {
            // Ýþlem sonucunu kontrol et
            if (data.success) {
                // Baþarýlý giriþ durumunda "LoginViewModel"i post et
                fetch('/Login/Login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        email: email,
                        password: password
                    })
                })
                    .then(response => response.json())
                    .then(data => {
                        // Baþarýlý giriþ durumunda "Home/Index" sayfasýna yönlendirme
                        if (data.success) {
                            window.location.href = '/Home/Index';
                        }
                    });
            } else {
                Swal.fire({
                    text: "Sorry, looks like there are some errors detected, please try again.",
                    icon: "error",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok, got it!",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                });
            }
        });
}
