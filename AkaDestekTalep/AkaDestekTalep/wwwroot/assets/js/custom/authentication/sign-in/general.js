// LoginViewModeli post etmek i�in i�lev
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
            // ��lem sonucunu kontrol et
            if (data.success) {
                // Ba�ar�l� giri� durumunda "LoginViewModel"i post et
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
                        // Ba�ar�l� giri� durumunda "Home/Index" sayfas�na y�nlendirme
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
