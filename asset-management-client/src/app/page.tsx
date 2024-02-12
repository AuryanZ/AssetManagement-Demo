"use client";
import React, { useEffect, useState } from "react";
import Header from "../../components/Header/header";
import { getAssets } from "@/api/assetsAPI";

export default function Home() {

  const [assetsData, setAssetsData] = useState(null);
  console.log("console log from Home.tsx");

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
  console.log("start rander DOM")

  // console.log(assetsData);

  return (
    <div className="App">
      <Header />
      <div className='container mx-auto'>
        {assetsData && (assetsData as any[]).map((asset) => (
          <div key={asset.id}>
            <h2>{asset.AssetName}</h2>
            <p>{asset.AssetStatus}</p>
          </div>
        ))}
      </div>
    </div>
  );
}
