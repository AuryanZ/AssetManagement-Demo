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
        // <div className="flex flex-col min-h-dvh-2" >
        <div className="grid grid-cols-6 gap-4" >
            {/* <div className="flex flex-1 justify-center items-center"> */}
            {/* <div className="w-1/4 min-h-screen px-8 py-10 bg-[#09A94E]"> */}
            <div className="max-w-xs bg-[#09A94E]">
                <div className="px-4 pt-10">
                    <VerticalNavBar />
                </div>
            </div>
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
        </div>
    );
}

export default AssetSearch;