$(function () {
   // Sidebar toggle behavior
   $('#sidebarCollapse').on('click', function () {
       $('#sidebar, #folderToClick').toggleClass('active');
   });
});