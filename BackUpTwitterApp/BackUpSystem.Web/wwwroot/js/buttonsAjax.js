$(function () {
    const btnField = $('#download-btn');
    console.log(btnField);

    const data = {
        'id': btnField.attr("parameter1"),
        'createdAt': btnField.attr("parameter2"),
        'likesCount': btnField.attr("parameter3"),
        'retweetsCount': btnField.attr("parameter4"),
        'text': btnField.attr("parameter5"),
        'tweetAuthor': btnField.attr("parameter6"),
        'tweetUrl': btnField.attr("parameter7")
    };

    console.log(data);

    btnField.click(function () {
        btnField.hide();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "tweet/download",
            data: JSON.stringify(data),
            datatype: "json",
            success: function (result) {

                console.log(result);
            },
            error: function (xmlhttprequest, textstatus, errorthrown) {
                console.log("error: " + errorthrown);
            }
        });
    });
});
