$(document).ready(function () {
    var url = "/Transactions/TransactionList";
    $("body").on("click", "#btnDeposit", function () {
        var amount = $("input[id=depositAmount]").val();

        //Check if positive amount
        if (amount >= 0) {
            amount = amount.replace('.', ',');
            $("#transaction-list").load(url, { amount: amount });
            location.reload();
        }
        else alert("Nemoguće uplatiti negativan iznos.");

        $("input[id=depositAmount]").val(0);
    });
});