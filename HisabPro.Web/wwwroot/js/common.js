function getMonthName(monthNumber, isFullname = false) {
    const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return isFullname == false ? monthNames[monthNumber - 1].slice(0, 3) : monthNames[monthNumber - 1];
}
