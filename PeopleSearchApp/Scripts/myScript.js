$("#searchedName").keyup(function () {
    var name = $('#searchedName').val();
    clearList();
    if (name.length < 1) {
        return;
    }
    var url = '/Home/SearchName/' + name;
    $.getJSON(url, function (response) {
        if (response.length < 1) {
            $('#personTableList').append('<h3 align="center">No Matches Found</h3>');
            return;
        }
        fillTable(response);
    });
});

function fullList(data) {
    $('#searchedName').val("");
    clearList();
    fillTable(data);
}

function clearList() {
    $("#personTableList").empty();
}

function fillTable(response) {
    if (response != null) {
        if ($('#personTableList').find("thead").length === 0) {
            var table = '<thead>' +
                            '<tr>' +
                                '<th>First Name</th>' +
                                '<th>Last Name</th>' +
                                '<th>Address</th>' +
                                '<th>Age</th>' +
                                '<th>Interests</th>' +
                                '<th>Picture</th>' +
                                '<th>API View</th>'
                            '</tr>' +
                        '/thead><tbody>';
            $('#personTableList').append(table);
        }
        for (var i = 0; i < response.length; i++) {
            var item = '<tr>' +
                            '<td>' + response[i].FirstName + '</td>' +
                            '<td>' + response[i].LastName + '</td>' +
                            '<td>' + response[i].StreetAddress + " " + response[i].City + " " + response[i].State + " " + response[i].Zip + " " + '</td>' +
                            '<td>' + response[i].Age + '</td>' +
                            '<td>' + response[i].Interests + '</td>' +
                            '<td><img src="\\' + response[i].PhotoPath + '" width="50"/></td>' +
                            '<td><a href="/api/People/' + response[i].PersonID + '"> API </a></td>'
                       '</tr>';
            $("#personTableList").append(item);
        }
        $("#personTableList").append('</tbody>');
    }
}

