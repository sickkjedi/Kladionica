﻿var bonus = {
    "bonus5": false,
    "applied5": false,
    "bonus10": false,
    "applied10": false
};
var totalQuota = 1.0;
var amount = 0;

$(document).ready(function () {
    var url = "/Home/PairsList";
    //Update pairs table on sport category select
    $("input[name=sport-select]").change(function () {
        var keyWord = $(this).val();
        $("#pairs-table").load(url, { sportName: keyWord });
    });

    //Update total winnings on bet amount field change
    $("input[id=betAmount]").change(function () {
        amount = $(this).val();
        UpdateWinnings();
    });
});

//Update win amount field
function UpdateWinnings() {
    amount = (amount * totalQuota).toFixed(2);
    $("#winAmount").html("<strong> " + amount.toString() + " KN" + "</strong>");
};

//Remove an item from the ticket table
function Remove(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("tr");
    var id = $("td", row).eq(0).html().trim();
    var type = $("td", row).eq(2).html().split(" -")[0];

    //Get the reference of the Table.
    var table = $("#tblTicket")[0];

    //Delete the Table row using it's Index.
    table.deleteRow(row[0].rowIndex);
    var quota = $("td", row).eq(2).html().split("- ")[1];

    UpdateTotalQuota(parseFloat(quota.replace(',', '.')) * -1.0);

    //Untoggle pair type button from pairs table
    $("#pairs-table").find("#" + id).find("[value=" + type + "]").button("toggle");

};

//Insert current total qouta
function UpdateTotalQuota(quota) {
    if (quota < 0) {
        totalQuota = (totalQuota / (-1.0 * quota)).toFixed(2);
    }
    else if (quota > 0) {
        totalQuota = (totalQuota * quota).toFixed(2);
    }
    if (bonus.bonus5 && !bonus.applied5) {
        totalQuota = (parseFloat(totalQuota) + 5.0).toFixed(2);
        bonus.applied5 = true;
    }
    if (bonus.bonus10 && !bonus.applied10) {
        totalQuota = (parseFloat(totalQuota) + 10.0).toFixed(2);
        bonus.applied10 = true;
    }
    $("#total-quota").html("<strong> " + totalQuota.toString() + "</strong>");
    UpdateWinnings();
};

//Return array of all pairs from the current ticket table
function GetTicketPairs() {
    var ticketPairs = [];
    $("#tblTicket TBODY TR").each(function () {
        var row = $(this);
        ticketPairs.push({
            "PairId": row.find("TD").eq(0).html().trim(),
            "Type": row.find("TD").eq(2).html().split(" -")[0]
        });
    });

    return ticketPairs;
};


function GetBonus() {
    var categories = [];

    //Load all pair categories from current ticket
    $("#tblTicket TBODY TR").each(function () {
        var row = $(this);
        categories.push(row["0"].dataset.info);
    });

    //Count the most occured category and how many different
    var counts = {}, max = 0, res, countsDiff = 0;
    for (var v in categories) {
        if (counts[categories[v]] == null) {
            counts[categories[v]] = 1;
            countsDiff += 1;
        }
        else {
            counts[categories[v]] += 1;
        }

        if (counts[categories[v]] > max) {
            max = counts[categories[v]];
            res = categories[v];
        }
    }


    //If any category appears 2 times show bonus5 popup
    if (counts[res] === 2 && !bonus.bonus5) {
        alert("Ako dodate još 1 par iz kategorije " + res + " ostvarite bonus od +5 na ukupnu kvotu!");
    }
    else if (counts[res] >= 3 && !bonus.applied5) {
        bonus.bonus5 = true;
        alert("Bonus od 3 ista sporta ostvaren! Dobili ste +5 na ukupnu kvotu.");
    }

    //If 3 or more different sports show bonus10
    if (countsDiff >= 3 && countsDiff < 7 && !bonus.bonus10) {
        alert("Dodajte još " + (7 - countsDiff) + " različitih sportova da ostvarite bonus od +10 na kvotu!");
    }
    else if (countsDiff >= 7 && !bonus.applied10) {
        bonus.bonus10 = true;
        alert("Bonus od 7 različitih sportova ostvaren! Dobili ste +10 na ukupnu kvotu.");
    }
};

//Add pairs to ticket table on type click
$("body").on("click", "#btnAdd", function () {
    //Reference the entire row of the clicked button
    var $btnRow = $(this).closest("tr");

    //Get bet type and quota from the button
    var betType = $(this).val();
    var quota = $(this).attr("title");

    //Get Pair ID and Full Name string from the button table row
    var pairId = $btnRow.find("td:nth-child(1)");
    var pairName = $btnRow.find("td:nth-child(2)");
    var pairCategory = $btnRow["0"].dataset.info;

    //Check if selected pair is already in current ticket
    var isChecked = false;
    var ticketPairs = GetTicketPairs();
    ticketPairs.forEach(function (pair) {
        if (pair.PairId === pairId.text().trim()) {
            alert("Par #" + pairId.text().trim() + " je već odabran.");
            isChecked = true;
        }
    });
    if (isChecked) return false;

    //Get the reference of the Table's TBODY element
    var tBody = $("#tblTicket > TBODY")[0];

    //Add Row
    var row = tBody.insertRow(-1);

    //Add Pair ID cell
    var cell = $(row.insertCell(-1));
    cell.html(pairId.text().trim());

    //Add Pair name cell
    cell = $(row.insertCell(-1));
    cell.html(pairName.text().trim());
    row.setAttribute("data-info", pairCategory);

    //Add Type and Quota cell
    cell = $(row.insertCell(-1));
    cell.html(betType + " - " + quota);

    //Add remove button
    cell = $(row.insertCell(-1));
    var btnRemove = $("<input />");
    btnRemove.attr("type", "button");
    btnRemove.attr("onclick", "Remove(this);");
    btnRemove.attr("class", "btn btn-sm btn-danger");
    btnRemove.val("X");
    cell.append(btnRemove);

    GetBonus();
    UpdateTotalQuota(parseFloat(quota.replace(',', '.')));
});


//Send ticket data
$("body").on("click", "#btnSubmit", function () {
    var ticketData = {
        "BetAmount": +$("input[id=betAmount]").val(),
        //Placeholder for authentication
        "UserID": 1,
        "BonusQuota5": bonus.bonus5,
        "BonusQuota10": bonus.bonus10
    };

    ticketData.TicketPairs = GetTicketPairs();

    //Send the JSON array to Controller using AJAX.
    $.ajax({
        type: "POST",
        url: "/Home/InsertTicket",
        data: JSON.stringify(ticketData),
        contentType: "application/json; charset=utf-8",
        dataType: "text/json",
        error: function (response) {
            var jsonResponse = JSON.parse(response.responseText);
            alert(jsonResponse.message);

            if (jsonResponse.success) {
                location.reload();
            }
        }
    });

});