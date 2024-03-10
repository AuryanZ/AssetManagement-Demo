"use client"
import { getAssets } from "@/api/assetsAPI";
import VerticalNavBar from "@/components/NavBar";
import { useEffect, useState } from "react";

interface IAsset {
    id: number;
    assetName: string;
    assetType: string;
    assetStatus: string;
}

const AssetSearch = () => {

    const [assets, setAssets] = useState<IAsset[]>();

    useEffect(() => {
        const fetchData = async () => {
            const assetsFetch = await getAssets();
            console.log(assetsFetch);
            assetsFetch && setAssets(assetsFetch.data);


        };
        fetchData()
    }, []);

    return (
        <div className="col-span-5 pt-4">
            <div className="px-4">
                <table className="table-auto w-full">
                    <thead>
                        <tr>
                            <th className="px-4 py-2">Asset ID</th>
                            <th className="px-4 py-2">Asset Name</th>
                            <th className="px-4 py-2">Asset Type</th>
                            <th className="px-4 py-2">Asset Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {assets && assets.map((asset: any, index: number) => (
                            <tr key={index}>
                                <td className="border px-4 py-2">{asset.id}</td>
                                <td className="border px-4 py-2">{asset.assetName}</td>
                                <td className="border px-4 py-2">{asset.assetType}</td>
                                <td className="border px-4 py-2">{asset.assetStatus}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                <div className="px-4">
                </div>
            </div>
        </div>
    );
}

export default AssetSearch;