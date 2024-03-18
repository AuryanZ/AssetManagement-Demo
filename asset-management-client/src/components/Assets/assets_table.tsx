import React, { useEffect, useState } from "react";

interface IAsset {
    showDetails: any;
    id: number;
    name: string;
    location: string;
    status: string;
    installDate: string;
    lastInspectionDate: string;
}


const DataProcess = (data: any) => {
    if (!data) return [];
    const processedData = data.map((asset: IAsset) => {
        return {
            id: asset.id,
            name: asset.name,
            location: asset.location,
            status: asset.status,
            installDate: new Date(asset.installDate).toLocaleDateString(
                'en-NZ',
                {
                    year: 'numeric',
                    month: 'short',
                    day: '2-digit'
                }),
            lastInspectionDate: new Date(asset.lastInspectionDate).getFullYear() === 1 
            ? "N/A"
            :new Date(asset.lastInspectionDate).toLocaleDateString(
                'en-NZ',
                {
                    year: 'numeric',
                    month: 'short',
                    day: '2-digit'
                })
        }
    });
    return processedData;
}

const AssetsTable = ({ assetsData }: { assetsData: any[] }) => {
    const [assets, setAssets] = useState<IAsset[]>(DataProcess(assetsData));
    console.log("assetsData ", assets);

    useEffect(() => {
        setAssets(DataProcess(assetsData));
    }, [assetsData]);

    // console.log("assetsData ", assets);

    const toggleDetails = (index: number) => {
        setAssets((assets ?? []).map((asset, i) => {
            if (i === index) {
                return { ...asset, showDetails: !asset.showDetails };
            }
            return asset;
        }));
    };

    return (
        <table className="AssetsTable table-auto">
            <thead>
                <tr>
                    <th className="border px-4 py-2">Asset ID</th>
                    <th className="border px-4 py-2">Asset Name</th>
                    <th className="border px-4 py-2">Location</th>
                    <th className="border px-4 py-2">Asset Status</th>
                    <th className="border px-4 py-2">Install Date</th>
                    <th className="border px-4 py-2">Latest Inspection Date</th>
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
                            <td className="border px-4 py-2">{asset.lastInspectionDate}</td>
                        </tr>
                        {asset.showDetails && (
                            <tr>
                                <td colSpan={5} className="border px-4 py-2 justify-start">
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
    )
};

export default AssetsTable;
