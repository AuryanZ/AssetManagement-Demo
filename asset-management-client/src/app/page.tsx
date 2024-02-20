"use client";
import React, { useEffect, useState } from "react";
import Header from "../../components/Header/header";
import Footer from "../../components/Footer/footer";
import { getAssets } from "@/api/assetsAPI";

export default function Home() {

  const [assetsData, setAssetsData] = useState<any[] | null>(null);

  // useEffect(() => {
  //   const fetchAssets = async () => {
  //     try {
  //       const data = await getAssets();
  //       setAssetsData(data);
  //     } catch (error) {
  //     }
  //   };
  //   fetchAssets();
  // }, []);

  return (
    <div className="App">
      <Header />
      {/* <div className='container mx-auto w-full my-5 center flex'>
        {assetsData ? (
          <table className='justify-center text-center items-center'>
          <thead>
            <tr>
              <th>id</th>
              <th>Name</th>
              <th>Type</th>
              <th>Description</th>
              <th>Location</th>
              <th>State</th>
            </tr>
          </thead>
          <tbody>
          {assetsData.map((item) => (
                <tr key={item.id}>
                  <td>{item.id}</td>
                  <td>{item.assetName}</td>
                  <td>{item.assetType}</td>
                  <td>{item.assetDescription}</td>
                  <td>{item.assetLocation}</td>
                  <td>{item.assetStatus}</td>
                </tr>
              ))}
            </tbody>
        </table>) : (<p>loading</p>)}
      </div> */}
      <Footer />
    </div>
  );
}
