import axios from "axios";
import React, { useEffect, useState } from "react";
import CategoryInfo from "./components/CategoryInfo";

const APIURL = process.env.REACT_APP_APIURL || "http://localhost:5000";

export default function LibraryChallengeResults() {
  const [categoryCatalogue, setCategoryCatalogue] = useState([]);

  useEffect(() => {
    (async function getBooksByCategories() {
      try {
        const resp = await axios.get(
          `${APIURL}/api/library/allBooksByCategory`
        );
        setCategoryCatalogue(resp.data);
      } catch (err) {
        console.log(`Failed to get data, ${err}`);
      }
    })();
  }, []);

  //Category has:
  // category   - Name
  // count      - # books
  // fineTotal  - total fines
  // books      - List of books information

  return (
    <div className="library-challenge-results">
      {categoryCatalogue.map((category, index) => {
        return <CategoryInfo key={index} category={category} />;
      })}
    </div>
  );
}

LibraryChallengeResults.defaultProps = {
  color: "blue",
};
