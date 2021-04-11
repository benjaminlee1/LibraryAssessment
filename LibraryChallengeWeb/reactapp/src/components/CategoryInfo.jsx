import React, { useState } from "react";
import BookInfo from "./BookInfo";

export default function CategoryInfo({ category }) {
  const [hideList, setHideList] = useState(false);

  function determineDueValue(dueDate) {
    var currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0);
    if (dueDate === null) {
      return "green";
    }

    var dueDateObj = new Date(dueDate);
    if (isNaN(dueDateObj.getTime())) {
      return "green";
    }
    dueDateObj.setHours(0, 0, 0, 0);

    if (currentDate.getTime() < dueDateObj.getTime()) {
      return "blue";
    } else if (currentDate.getTime() > dueDateObj.getTime()) {
      return "red";
    } else {
      return "orange";
    }
  }

  return (
    <div>
      <h1>{category.category}</h1>
      <button onClick={() => setHideList(!hideList)}>Expand/Collapse</button>
      <p>Books in category: {category.count}</p>
      <p>Outstanding Fees: {Math.round(category.fineTotal * 100) / 100} $ </p>
      <div style={{ display: hideList ? "none" : "block" }}>
        {category.books.map((book, index) => (
          <BookInfo
            key={index}
            book={book}
            due={determineDueValue(book.dueDate)}
          />
        ))}
      </div>
    </div>
  );
}
