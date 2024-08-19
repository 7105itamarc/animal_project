var connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();

connection.on("NewMessage", (sender, message) => {
    $("#chatLog").html($("#chatLog").html() + " Message from " + sender + ": " + message + "<br/>");
});

connection.start().catch(err => console.error(err.toString()));

$("#all").on("click", function () {
    var sender = $("#username").val();
    var message = $("#message").val();
    connection.invoke("MessageAll", sender, message);
});