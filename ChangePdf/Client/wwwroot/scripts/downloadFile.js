function downloadFile(url, fileName) {
    var a = document.createElement("a");
    a.href = url;
    a.download = fileName;
    a.click();
}
