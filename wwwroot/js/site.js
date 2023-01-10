function startAutoLogout() {
    // setup timeout that will occur when session has expired (20 minutes = 60000 * 20 milliseconds)
    window.setTimeout(() => {document.location = "/Admin/Logout";}, 1200000);
    // setup timeout that will occur when session about to expire to warn user
    window.setTimeout(() => document.getElementById("lblExpire").innerHTML = "WARNING : You are about to be automatically logout in 2 minutes!", 1080000);
}