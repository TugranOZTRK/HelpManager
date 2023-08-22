"use strict";

// KTModalCreateProjectBudget
var KTModalCreateProjectBudget = function () {
    var e, t, r, o, a;

    return {
        init: function () {
            o = KTModalCreateProject.getForm();
            a = KTModalCreateProject.getStepperObj();
            e = KTModalCreateProject.getStepper().querySelector('[data-kt-element="budget-next"]');
            t = KTModalCreateProject.getStepper().querySelector('[data-kt-element="budget-previous"]');
            r = FormValidation.formValidation(o, {
                fields: {
                    budget_setup: {
                        validators: {
                            notEmpty: {
                                message: "B�t�e miktar� gereklidir"
                            },
                            callback: {
                                message: "B�t�e miktar� 100$'dan b�y�k olmal�d�r",
                                callback: function (e) {
                                    var t = e.value;
                                    if (t = t.replace(/[$,]+/g, ""), parseFloat(t) < 100) return !1;
                                }
                            }
                        }
                    },
                    budget_usage: {
                        validators: {
                            notEmpty: {
                                message: "B�t�e kullan�m tipi gereklidir"
                            }
                        }
                    },
                    budget_allow: {
                        validators: {
                            notEmpty: {
                                message: "B�t�eye izin verme gereklidir"
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: ".fv-row",
                        eleInvalidClass: "",
                        eleValidClass: ""
                    })
                }
            });

            KTDialer.getInstance(o.querySelector("#kt_modal_create_project_budget_setup")).on("kt.dialer.changed", function () {
                r.revalidateField("budget_setup");
            });

            e.addEventListener("click", function (t) {
                t.preventDefault();
                e.disabled = !0;
                r && r.validate().then(function (t) {
                    console.log("validated!");
                    if (t === "Valid") {
                        e.setAttribute("data-kt-indicator", "on");
                        setTimeout(function () {
                            e.removeAttribute("data-kt-indicator");
                            e.disabled = !1;
                            a.goNext();
                        }, 1500);
                    } else {
                        e.disabled = !1;
                        Swal.fire({
                            text: "�zg�n�m, baz� hatalar alg�land�, l�tfen tekrar deneyin.",
                            icon: "error",
                            buttonsStyling: !1,
                            confirmButtonText: "Tamam, anlad�m!",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        });
                    }
                });
            });

            t.addEventListener("click", function () {
                a.goPrevious();
            });
        }
    };
}();

// ... Di�er KTModalCreateProject fonksiyonlar� burada olacak ...

// KTModalCreateProject init
var KTModalCreateProject = function () {
    var e, t, r;
    return {
        init: function () {
            e = document.querySelector("#kt_modal_create_project_stepper");
            r = document.querySelector("#kt_modal_create_project_form");
            t = new KTStepper(e);
        },
        getStepperObj: function () {
            return t;
        },
        getStepper: function () {
            return e;
        },
        getForm: function () {
            return r;
        }
    };
}();

// KTUtil.onDOMContentLoaded
KTUtil.onDOMContentLoaded(function () {
    document.querySelector("#kt_modal_create_project") && (KTModalCreateProject.init(), KTModalCreateProjectType.init(), KTModalCreateProjectBudget.init(), KTModalCreateProjectSettings.init(), KTModalCreateProjectTeam.init(), KTModalCreateProjectTargets.init(), KTModalCreateProjectFiles.init(), KTModalCreateProjectComplete.init())
});
