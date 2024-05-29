switch (window.location.pathname.split('/')[1]) {
    case 'ComicBooks':
        document.querySelector('#comicBooksBtn').classList.add('active');
        break;
    case '/':
        document.querySelector('#homeBtn').classList.add('active');
        break;
    default :
        document.querySelector('#homeBtn').classList.add('active');
        break;
}


document.querySelector('#comicBooksBtn').addEventListener('click', () => {
    window.location.href = "ComicBooks";
});

document.querySelector('#homeBtn').addEventListener('click', () => {
    window.location.href = "/";
});