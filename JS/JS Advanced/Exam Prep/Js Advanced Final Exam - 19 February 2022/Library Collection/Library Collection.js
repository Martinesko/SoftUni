class LibraryCollection{
 constructor(capacity) {
 this.capasity = capacity;
 this.books = [];
 }
    addBook (bookName, bookAuthor){
     if (this.capasity <= this.books.length){
         throw new Error('Not enough space in the collection.');
     }
     this.books.push({bookName, bookAuthor, payed: false});
     return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }
    payBook( bookName ){
     let book = this.books.find(x=>x.bookName === bookName);
     if (book === null || book === undefined|| book===''){
         throw new Error(`${bookName} is not in the collection.`);
     }
     if (book.payed === true){
         throw new Error(`${bookName} has already been paid.`);
     }
     book.payed = true;
     return `${bookName} has been successfully paid.`;
    }
    removeBook(bookName){
        let book = this.books.find(x=>x.bookName === bookName);
        if (book === null || book === undefined|| book===''){
            throw new Error(`The book, you're looking for, is not found.`);
        }
        if (book.payed === false){
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }
        this.books.splice(this.books.indexOf(book),1);
        return `${bookName} remove from the collection.`;
    }
    getStatistics(bookAuthor){
     if(bookAuthor === undefined) {
         let result = `The book collection has ${this.capasity - this.books.length} empty spots left.`;
         let sortedBooks = this.books.sort((a, b) => a - b);
         for (const sortedBook of sortedBooks) {
             let isPaid = '';
             if (sortedBook.payed === true) {
                 isPaid = `Has Paid`;
             } else {
                 isPaid = `Not Paid`;
             }
             result += `\n${sortedBook.bookName} == ${sortedBook.bookAuthor} - ${isPaid}.`;
         }
         return result;
     }
     let result = '';
        let AuthorBooks = [];
        for (const book of this.books) {
            if(book.bookAuthor === bookAuthor){
                AuthorBooks.push(book);
            }
        }
        if (AuthorBooks.length === 0){
            throw new Error(`${bookAuthor} is not in the collection.`);
        }
        for (const authorBook of AuthorBooks) {
            let isPaid = '';
            if(authorBook.payed === true){
                isPaid = `Has Paid`;
            }
            else{
                isPaid = `Not Paid`;
            }
            result += `${authorBook.bookName} == ${bookAuthor} - ${isPaid}.\n`;
        }
        return result.trimEnd();
    }
}
