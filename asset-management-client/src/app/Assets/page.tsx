"use client"
import { getAssets } from "@/api/assetsAPI";
import React from "react";
import { useEffect, useState } from "react";

interface IAsset {
    showDetails: any;
    id: number;
    name: string;
    location: string;
    status: string;
    installDate: Date;
}

const DataProcess = (data: any) => {
    if (!data) return [];
    const processedData = data.map((asset: IAsset) => {
        return {
            id: asset.id,
            name: asset.name,
            location: asset.location,
            status: asset.status,
            installDate: new Date(asset.installDate).toLocaleDateString('en-NZ', { year: 'numeric', month: 'short', day: '2-digit' })
        }
    });
    return processedData;
}

const AssetSearch = () => {

    const [assets, setAssets] = useState<IAsset[]>();
    const [page, setPage] = useState(1);
    const [itemsPerPage, setItemsPerPage] = useState(3);

    const toggleDetails = (index: number) => {
        setAssets((assets ?? []).map((asset, i) => {
            if (i === index) {
                return { ...asset, showDetails: !asset.showDetails };
            }
            return asset;
        }));
    };

    useEffect(() => {
        const fetchData = async () => {
            const assetsFetch = await getAssets();
            console.log(assetsFetch);
            assetsFetch && setAssets(DataProcess(assetsFetch.data));
            // assetsFetch && setAssets(assetsFetch.data);


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
                            <th className="px-4 py-2">Location</th>
                            <th className="px-4 py-2">Asset Status</th>
                            <th className="px-4 py-2">Install Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {assets && assets.map((asset: any, index: number) => (
                            <React.Fragment key={index}>
                                <tr onClick={() => toggleDetails(index)} className="cursor-pointer">
                                    <td className="border px-4 py-2">{asset.id}</td>
                                    <td className="border px-4 py-2">{asset.name}</td>
                                    <td className="border px-4 py-2">{asset.location}</td>
                                    <td className="border px-4 py-2">{asset.status}</td>
                                    <td className="border px-4 py-2">{asset.installDate}</td>
                                </tr>
                                {asset.showDetails && (
                                    <tr>
                                        <td colSpan={5} className="border px-4 py-2">
                                            {/* Display additional details here. For example: */}
                                            <p>Additional detail 1: {asset.detail1}</p>
                                            <p>Additional detail 2: {asset.detail2}</p>
                                        </td>
                                    </tr>
                                )}
                            </React.Fragment>
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