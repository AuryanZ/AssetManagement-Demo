"use client";
import React, { useEffect, useState } from "react";
import Header from "../../components/Header/header";

export default function Home() {

  const [assetsData, setAssetsData] = useState(null);

  useEffect(() => {
    const fetchAssets = async () => {
      try {
        const response = await fetch('/api/assets');
        const data = await response.json();
        setAssetsData(data);
      } catch {
        console.error('Error fetching data');
      }
    };
    fetchAssets();
  }, []);

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
