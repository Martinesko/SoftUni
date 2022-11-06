class ArtGallery{
    constructor(creator) {
        this.creator = creator;
        this.posibleArticles = { "picture":200,"photo":50,"item":250 };
        this.listOfArticles = [];
        this.guests = [];
    }
    addArticle( articleModel, articleName, quantity ){
        if(articleModel.toLowerCase() !== 'picture' && articleModel.toLowerCase() !== 'photo'&& articleModel.toLowerCase() !== 'item'){
            throw new Error("This article model is not included in this gallery!");
        }
    }
}