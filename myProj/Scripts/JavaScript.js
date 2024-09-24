@using System.Web.Helpers;
var modelData = @Html.Raw(Json.Encode(Model));
console.log(modelData);