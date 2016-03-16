/**
 * نام جدول
 */
var tableId = tableId;
/**
 * صفحه
 */
var row = 1;
/**
 * 
 */
var canLoad = true;
/**
* بعد از تغییر اسکرول صفحه این رخداد فراخوانی خواهد شد
*/
$(window).scroll(function () {
    // شرط برسی می‌شود که اگر ارتفاع کلی صفحه کوچکتر یا مساوی موقعیت
    // مکان اسکرول + ارتفاع صفحه نمایشی باشد شرط برابر خواهد بود با مقدار 
    // true
    if ($(document).height() <= ($(window).scrollTop() + $(window).height()) && canLoad) {
        SendObj('/Home/Index?skip=' + row, '{}', function (data) {
            if (data === "") { canLoad = false; return;}
            searchResult(data, true);
            row++;
        }, function () { alert('خطا در ارتباط با سرور') });
    }
});
/**
 * 
 * @param {} data 
 * @param {} append 
 * @returns {} 
 */
function searchResult(data, append) {
    if (tableId == null)
        tableId = "tblDefault";
    if (typeof append === 'undefined' || append === "false") {
        $("#" + tableId + " tbody").empty();
    }
    var array = data.split('</tr>');
    for (var i = 0; i < array.length - 1; i++) {
        $("#" + tableId + " tbody").append($(array[i])[0]);
    }
}
/**
 * 
 * @param {} model 
 * @param {} data 
 * @param {} success 
 * @param {} error 
 * @returns {} 
 */
function SendObj(model, data, success, error, contentType) {
    var dataType = "json";
    if (typeof contentType == "undefined") {
        contentType = "application/html; charset=utf-8";
        dataType = "html";
    }
    $.ajax({
        type: "POST",
        url: model,
        data: data,
        contentType: contentType,
        dataType: dataType,
        success: function (data) {
            success(data);
        },
        error: function (data) {
            //error(data);
        }
    });
}