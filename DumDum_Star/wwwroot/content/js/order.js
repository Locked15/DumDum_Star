function updateOrderData(id, name) {
    let count = document.getElementById(`Count.${name}`).value

    let location = document.location.origin;
    let getAddress = location + `/User/UpdateOrderDetails?cyberId=${id}&count=${count}`
    window.location.href = getAddress
}
