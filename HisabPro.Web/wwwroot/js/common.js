function getMonthName(monthNumber, isFullname = false) {
    const monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return isFullname == false ? monthNames[monthNumber - 1].slice(0, 3) : monthNames[monthNumber - 1];
}

// Function to generate random colors for charts
function generateColors(count) {
    let colors = [];
    if (count <= pieChartColors.length) {
        // Take the first 10 items
        colors = pieChartColors.slice(0, count);
    }
    else {
        for (let i = 0; i < count; i++) {
            const r = Math.floor(Math.random() * 255);
            const g = Math.floor(Math.random() * 255);
            const b = Math.floor(Math.random() * 255);
            colors.push(`rgba(${r}, ${g}, ${b}, 0.9)`);
        }
    }
    return colors;
}

const pieChartColors = [
    'rgba(75, 192, 192, 0.9)',  // Teal
    'rgba(255, 99, 132, 0.9)', // Red
    'rgba(54, 162, 235, 0.9)', // Blue
    'rgba(255, 206, 86, 0.9)', // Yellow
    'rgba(153, 102, 255, 0.9)',// Purple
    'rgba(255, 159, 64, 0.9)', // Orange
    'rgba(199, 199, 199, 0.9)',// Grey
    'rgba(232, 99, 132, 0.9)', // Light Red
    'rgba(99, 255, 132, 0.9)', // Light Green
    'rgba(132, 99, 255, 0.9)', // Light Purple
    'rgba(60, 179, 113, 0.9)', // Medium Sea Green
    'rgba(100, 149, 237, 0.9)',// Cornflower Blue
    'rgba(255, 105, 180, 0.9)',// Hot Pink
    'rgba(72, 209, 204, 0.9)', // Medium Turquoise
    'rgba(210, 105, 30, 0.9)', // Chocolate
    'rgba(255, 69, 0, 0.9)',   // Red-Orange
    'rgba(144, 238, 144, 0.9)',// Light Green
    'rgba(245, 222, 179, 0.9)',// Wheat
    'rgba(238, 130, 238, 0.9)',// Violet
    'rgba(70, 130, 180, 0.9)', // Steel Blue
    'rgba(250, 128, 114, 0.9)',// Salmon
    'rgba(221, 160, 221, 0.9)',// Plum
    'rgba(255, 228, 181, 0.9)',// Moccasin
    'rgba(244, 164, 96, 0.9)', // Sandy Brown
    'rgba(176, 224, 230, 0.9)' // Powder Blue
];