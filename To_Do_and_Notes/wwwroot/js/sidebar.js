function ToggleTest() {
    var sidebarCollapse = document.getElementById('sidebarCollapse');
    sidebarCollapse.addEventListener('click', function () {
        document.getElementById('sidebar').classList.toggle('active');
        document.getElementById('content').classList.toggle('active');
    });
}