"use client";
import React, { useEffect, useState } from "react";
import Header from "../../components/Header/header";
import { getAssets } from "@/api/assetsAPI";

export default function Home() {

  const [assetsData, setAssetsData] = useState<Array<{ 
    id: number; 
    assetName: string; 
    assetType: string; 
    assetDescription: string; 
    assetLocation: string; 
    assetStatus: string; 
  }> | null>(null);

  useEffect(() => {
    console.log("useEffect");
    const fetchAssets = async () => {
      console.log("fetching data...")
      try {
        console.log("Trying to fetch data...");
        const data = await getAssets();
        setAssetsData(data);
      } catch (error) {
        console.error('Error fetching data');
      }
    };
    fetchAssets();
  }, []);

  return (
    <div className="App">
      <Header />
      <div className='container mx-auto'>
        {assetsData ? (
          <table>
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
      </div>
    </div>
  );
}
