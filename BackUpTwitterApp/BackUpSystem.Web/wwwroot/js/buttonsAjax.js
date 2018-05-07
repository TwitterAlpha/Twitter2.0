<script>
    $(function () {
        $('.btn').click(function () {

            const data = {
                'id': $(this).attr("parameter1"),
                'name': $(this).attr("parameter2"),
                'backgroundImage': $(this).attr("parameter3"),
                'description': $(this).attr("parameter4"),
                'followersCount': $(this).attr("parameter5"),
                'followingCount': $(this).attr("parameter6"),
                'imageUrl': $(this).attr("parameter7"),
                'tweetsCount': $(this).attr("parameter8"),
                'username': $(this).attr("parameter9"),
                'isInFavorites': Boolean($(this).attr("parameter10"))
            };

            const buttonId = $(this).attr('id');
            console.log(buttonId);

            let postUrl;
            const messageId = `#message-${data.id}`;

            if (buttonId.startsWith('follow')) {
                postUrl = '/twitteraccount/AddTwitterAccountToFavorites';
            }
            else {
                postUrl = '/twitteraccount/UnfollowTwitterAccount';
            }
            console.log(postUrl);

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: postUrl,
                data: JSON.stringify(data),
                datatype: "json",
                success: function (result) {

                    if (buttonId.startsWith('follow')) {
                        console.log('follow');
                        $(`#${buttonId}`).css('visibility', 'hidden');
                        $(`#unfollow-${data.id}`).css('visibility', 'visible');
                    }
                    else {
                        console.log('unfollow');
                        $(`#${buttonId}`).css('visibility', 'hidden');
                        $(`#follow-${data.id}`).css('visibility', 'visible');
                    }

                    $(messageId).text(result).css({ 'color': 'green', 'font-weight': 'normal' }).show().delay(3000).fadeOut();
                    $('#sidebar').load("/Home/UpdateFavoriteUsersInLayout");
                },
                error: function (result) {
                    $(messageId).text("Error: " + result).css({ 'color': 'red', 'font-weight': 'normal' }).show().delay(3000).fadeOut();;
                }
            });
        });
    });
</script>