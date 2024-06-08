let aux_profileBtn = document.querySelector('#profileBtn');

switch (window.location.pathname.split('/')[1]) {
    case 'ComicBooks':
        document.querySelector('#comicBooksBtn').classList.add('active');
        break;
    case 'OrderHistory':
        document.querySelector('#orderHistoryBtn').classList.add('active');
        break;
    case 'profile':
        if(aux_profileBtn){
            document.querySelector('#profileBtn').classList.add('active');
        }
        break;
    case '/':
        document.querySelector('#homeBtn').classList.add('active');
        break;
    case '':
        document.querySelector('#homeBtn').classList.add('active');
        break;
}

// Commented because otherwise the page is refreshed and the user is Logged out automatically
// document.querySelector('#comicBooksBtn').addEventListener('click', () => {
//     window.location.href = "ComicBooks";
// });

// document.querySelector('#homeBtn').addEventListener('click', () => {
//     window.location.href = "/";
// });

// if(aux_profileBtn){
//     document.querySelector('#profileBtn').addEventListener('click', () => {
//         window.location.href = "profile";
//     })
// }