$(function () {
    $(".btn").click(function () {
        const data = {
            'id': $(this).attr("parameter1"),
            'createdAt': $(this).attr("parameter2"),
            'likesCount': $(this).attr("parameter3"),
            'retweetsCount': $(this).attr("parameter4"),
            'text': $(this).attr("parameter5"),
            'tweetAuthor': $(this).attr("parameter6"),
            'tweetUrl': $(this).attr("parameter7")
        };

        console.log(data);
        const btnId = "#btn-" + data.id;
        const messageId = "#message" + data.id;
        let postUrl;

        if (data.createdAt != undefined) {
            postUrl = "/tweet/download";
        }
        else {
            postUrl = "/tweet/delete";
        }
        console.log(postUrl);
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: postUrl,
            data: JSON.stringify(data),
            datatype: "json",
            success: function (result) {

                $(btnId).hide();

                $(messageId).text(result).css({ 'color': 'green', 'font-weight': 'normal' }).show().delay(3000).fadeOut();
            },
            error: function (result) {
                $(messageId).text("Error: " + result).css({ 'color': 'red', 'font-weight': 'normal' }).show().delay(3000).fadeOut();;
            }
        });
    });
});