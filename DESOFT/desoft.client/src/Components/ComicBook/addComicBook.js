var title = document.getElementById('title');
var description = document.getElementById('description');
var author = document.getElementById('author');
var version = document.getElementById('version');
var publishingDate = document.getElementById('publishingDate');
var price = document.getElementById('price');

title.addEventListener('change', () => {
    if (title.value != '' && description != '' && author != '' && version.value != '' && publishingDate != '' && price != '') {
        document.querySelector('#addBtn')?.removeAttribute('disabled');

    } else {
        document.querySelector('#addBtn')?.setAttribute('disabled', 'true');
    }
});

description.addEventListener('change', () => {
    if (title.value != '' && description != '' && author != '' && version.value != '' && publishingDate != '' && price != '') {
        document.querySelector('#addBtn')?.removeAttribute('disabled');

    } else {
        document.querySelector('#addBtn')?.setAttribute('disabled', 'true');
    }
});

author.addEventListener('change', () => {
    if (title.value != '' && description != '' && author != '' && version.value != '' && publishingDate != '' && price != '') {
        document.querySelector('#addBtn')?.removeAttribute('disabled');

    } else {
        document.querySelector('#addBtn')?.setAttribute('disabled', 'true');
    }
});

version.addEventListener('change', () => {
    if (title.value != '' && description != '' && author != '' && version.value != '' && publishingDate != '' && price != '') {
        document.querySelector('#addBtn')?.removeAttribute('disabled');

    } else {
        document.querySelector('#addBtn')?.setAttribute('disabled', 'true');
    }
});

publishingDate.addEventListener('change', () => {
    if (title.value != '' && description != '' && author != '' && version.value != '' && publishingDate != '' && price != '') {
        document.querySelector('#addBtn')?.removeAttribute('disabled');

    } else {
        document.querySelector('#addBtn')?.setAttribute('disabled', 'true');
    }
});

price.addEventListener('change', () => {
    if (title.value != '' && description != '' && author != '' && version.value != '' && publishingDate != '' && price != '') {
        document.querySelector('#addBtn')?.removeAttribute('disabled');

    } else {
        document.querySelector('#addBtn')?.setAttribute('disabled', 'true');
    }
});