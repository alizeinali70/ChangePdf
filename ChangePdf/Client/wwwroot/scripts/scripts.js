window.getCursorPosition = (elementId) => {
    const element = document.getElementById(elementId);
    if (!element) {
        throw new Error(`Element with id '${elementId}' not found.`);
    }
    return {
        selectionStart: element.selectionStart,
        selectionEnd: element.selectionEnd
    };
};