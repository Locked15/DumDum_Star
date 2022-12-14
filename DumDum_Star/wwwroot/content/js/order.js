var idVariableName = "cyberWareId";
var countName = "count";

function updateOrderData(id, name) {
    let count = document.getElementById(`Count.${name}`).value

    let location = document.location.origin;
    let getAddress = location + `/Order/UpdateOrderDetails?${idVariableName}=${id}&${countName}=${count}`
    window.location.href = getAddress
}
