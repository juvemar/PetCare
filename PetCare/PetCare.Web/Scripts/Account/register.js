CheckIfVet();

function CheckIfVet() {
    $(document).ready(function () {
        $('#isVetCheckbox').change(function () {
            $('#vetInfo').css('display', 'inline');
            if ($(this).is(":checked")) {
                $('#vetInfo').show();
            } else {
                $('#vetInfo').hide();
            }
        });
    });
};