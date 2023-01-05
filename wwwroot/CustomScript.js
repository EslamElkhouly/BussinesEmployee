function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteTd = 'deleteTd_' + uniqueId;
    var confirmDelete = 'confirmDelete_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteTd).hide();
        $('#' + confirmDelete).show();
    }
    else {
        $('#' + deleteTd).show();
        $('#' + confirmDelete).hide();
    }
}