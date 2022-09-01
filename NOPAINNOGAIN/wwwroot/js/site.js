// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function BuscaCep() {
    $(document).ready(function () {

        function limpa_formulário_cep() {
            $("#Endereco_Logradouro").val("");
            $("#Endereco_Bairro").val("");
            $("#Endereco_Cidade").val("");
            $("#Endereco_Estado").val("");
        }



        $("#cep").blur(function () {

            var cep = $(this).val().replace(/\D/g, '');

            if (cep != "") {

                var validacep = /^[0-9]{8}$/;

                if (validacep.test(cep)) {

                    $("#Endereco_Logradouro").val("...");
                    $("#Endereco_Bairro").val("...");
                    $("#Endereco_Cidade").val("...");
                    $("#Endereco_Estado").val("...");


                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {

                                $("#Endereco_Logradouro").val(dados.logradouro);
                                $("#Endereco_Bairro").val(dados.bairro);
                                $("#Endereco_Cidade").val(dados.localidade);
                                $("#Endereco_Estado").val(dados.uf);

                            }
                            else {
                                limpa_formulário_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                }
                else {
                    limpa_formulário_cep();
                    alert("Formato de CEP inválido.");
                }
            }
            else {
                limpa_formulário_cep();
            }

        });

    });
}

function AjaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {

                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#EnderecoTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog)
                        }
                    }
                });
                return false;
            });
        }
    });
}

//VALIDAR CPF
//    var cpf = "169.169.000-75";
//    cpf = "469.957.937-06";
//function validarCpf(cpf = 0) {
//    cpf = cpf.replace(/\.|-/g, ""); 

//    soma = 0;

//    return true;
//}

/*validarCpf(cpf);*/

//function validarCPF(cpf) {
//    cpf = cpf.replace(/[^\d]+/g, '');
//    if (cpf == '') return false;
//    // Elimina CPFs invalidos conhecidos	
//    if (cpf.length != 11 ||
//        cpf == "00000000000" ||
//        cpf == "11111111111" ||
//        cpf == "22222222222" ||
//        cpf == "33333333333" ||
//        cpf == "44444444444" ||
//        cpf == "55555555555" ||
//        cpf == "66666666666" ||
//        cpf == "77777777777" ||
//        cpf == "88888888888" ||
//        cpf == "99999999999")
//        return false;
//    // Valida 1o digito	
//    add = 0;
//    for (i = 0; i < 9; i++)
//        add += parseInt(cpf.charAt(i)) * (10 - i);
//    rev = 11 - (add % 11);
//    if (rev == 10 || rev == 11)
//        rev = 0;
//    if (rev != parseInt(cpf.charAt(9)))
//        return false;
//    // Valida 2o digito	
//    add = 0;
//    for (i = 0; i < 10; i++)
//        add += parseInt(cpf.charAt(i)) * (11 - i);
//    rev = 11 - (add % 11);
//    if (rev == 10 || rev == 11)
//        rev = 0;
//    if (rev != parseInt(cpf.charAt(10)))
//        return false;
//    return true;
//}

//function funcaoCPF(el) {

//    if (!validarCPF(el.value)) {

//        var span = document.getElementById("cpfvalido");
//        span.classList.add("invisivel");
//        el.classList.add("inputRed");
//        span.classList.remove("spanCPFValido");
//        var span = document.getElementById("cpfinvalido");
//        span.classList.remove("invisivel");
//        span.classList.add("spanCPF");
//    }

//    else {
//        var span = document.getElementById("cpfinvalido");
//        span.classList.add("invisivel");
//        el.classList.remove("inputRed");
//        el.classList.add("inputgreen");
//        span.classList.remove("spanCPF");
//        var spanvalido = document.getElementById("cpfvalido")
//        spanvalido.classList.remove("invisivel")

//    }
//}




//function AjaxModal() {
//    $(document).ready(function () {
//        $(function () {
//            $.ajaxSetup({ cache: false });

//            $("a[data-modal]").on("click",
//                function (e) {
//                    $('#myModalContent').load(this.href,
//                        function () {
//                            $('#myModal').modal({
//                                keyboard: true
//                            },
//                                'show');
//                            bindForm(this);
//                        });
//                    return false;
//                });
//        });

//        function bindForm(dialog) {
//            $('form', dialog).submit(function () {
//                $.ajax({
//                    url: this.action,
//                    type: this.method,
//                    data: $(this).serialize(),
//                    success: function (result) {

//                        if (result.success) {
//                            $('#myModal').modal('hide');
//                            $('#EnderecoTarget').load(result.url);
//                        } else {
//                            $('#myModalContent').html(result);
//                            bindForm(dialog)
//                        }
//                    }
//                });
//                return false;
//            });
//        }
//    });
//}


