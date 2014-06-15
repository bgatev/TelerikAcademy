(function () {
    var allItems = [
        {
            value: 1,
            text: 'One'
        },
        {
            value: 2,
            text: 'Two'
        },
        {
            value: 3,
            text: 'Three'
        },
        {
            value: 4,
            text: 'Four'
        }
    ];


    var post = { items: allItems };
    var htmlTemplate = document.getElementById("items-template").innerHTML;
    var postTemplate = Handlebars.compile(htmlTemplate);

    var container = document.getElementById("mainContainer");
    container.innerHTML = postTemplate(post);
}());