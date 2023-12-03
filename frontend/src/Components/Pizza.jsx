import React, { useState, useEffect } from "react";
import axios from "axios";

// imports
import PizzaList from "./PizzaList";

const term = "Pizza";

const Pizza = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    fetchPizzaData();
  }, []);

  const fetchPizzaData = async () => {
    try {
      let respone = await axios.get(`https://localhost:5023/api/pizza`);
      setData(respone.data);
    } catch (error) {
      console.warn("Error in fetchPizzaData, Pizza.jsx", error);
    }
  };

  const handleCreate = async (item) => {
    try {
      const response = await axios.post(
        "https://localhost:5023/api/pizza",
        item
      );
    } catch (error) {
      console.warn("Error in handleUpdate a new Pizza, in Pizza.jsx", error);
    }
  };

  const handleUpdate = async (item) => {
    try {
      const response = await axios.put(
        `https://localhost:5023/api/pizza/${item.id}`,
        item
      );
    } catch (error) {
      console.warn(
        "Error in handleUpdate an existing pizza, in Pizza.jsx",
        error
      );
    }
  };

  const handleDelete = async (id) => {
    try {
      const response = await axios.delete(
        `https://localhost:5023/api/pizza/${id}`
      );
    } catch (error) {
      console.warn("Error in handleDelete Pizza by id, in Pizza.jsx", error);
    }
  };

  return (
    <div>
      <PizzaList
        name={term}
        data={data}
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        onDelete={handleDelete}
      />
    </div>
  );
};

export default Pizza;
